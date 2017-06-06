using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ATT.Examples.O365.APIs.Data;
using ATT.Examples.O365.APIs.Models;

namespace O365APIs.Utils {

  public class EFADALTokenCache : TokenCache {
    private O365APIsContext db = new O365APIsContext();
    string User;
    PerWebUserCache Cache;

    // constructor
    public EFADALTokenCache(string user) {
      // associate the cache to the current user of the web app
      User = user;

      this.AfterAccess = AfterAccessNotification;
      this.BeforeAccess = BeforeAccessNotification;
      this.BeforeWrite = BeforeWriteNotification;

      // look up the entry in the DB
      Cache = db.PerWebUserCacheList.FirstOrDefault(c => c.WebUserUniqueId == User);
      // place the entry in memory
      this.Deserialize((Cache == null) ? null : Cache.CacheBits);
    }

    // clean up the DB
    public override void Clear() {
      base.Clear();
      foreach (var cacheEntry in db.PerWebUserCacheList)
        db.PerWebUserCacheList.Remove(cacheEntry);
      db.SaveChanges();
    }

    // Notification raised before ADAL accesses the cache.
    // This is your chance to update the in-memory copy from the DB, if the in-memory version is stale
    void BeforeAccessNotification(TokenCacheNotificationArgs args) {
      if (Cache == null) {
        // first time access
        Cache = db.PerWebUserCacheList.FirstOrDefault(c => c.WebUserUniqueId == User);
      } else {   // retrieve last write from the DB
        var status = from e in db.PerWebUserCacheList
                     where (e.WebUserUniqueId == User)
                     select new {
                       LastWrite = e.LastWrite
                     };
        // if the in-memory copy is older than the persistent copy
        if (status.First().LastWrite > Cache.LastWrite)
        //// read from from storage, update in-memory copy 
        {
          Cache = db.PerWebUserCacheList.FirstOrDefault(c => c.WebUserUniqueId == User);
        }
      }


      this.Deserialize((Cache == null) ? null : Cache.CacheBits);
    }
    // Notification raised after ADAL accessed the cache.
    // If the HasStateChanged flag is set, ADAL changed the content of the cache
    void AfterAccessNotification(TokenCacheNotificationArgs args) {
      // if state changed
      if (this.HasStateChanged) {
        Cache = new PerWebUserCache {
          WebUserUniqueId = User,
          CacheBits = this.Serialize(),
          LastWrite = DateTime.Now
        };
        //// update the DB and the lastwrite                
        db.Entry(Cache).State = Cache.EntryId == 0 ? EntityState.Added : EntityState.Modified;
        db.SaveChanges();
        this.HasStateChanged = false;
      }
    }
    void BeforeWriteNotification(TokenCacheNotificationArgs args) {
      // if you want to ensure that no concurrent write take place, use this notification to place a lock on the entry
    }
  }

}