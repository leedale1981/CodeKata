module BubbleSort

let bubblesort (input: int []): int [] = 
    let mutable swoped = false

    for index = 0 to input.Length do
        let first = input[index]
        let nextIndex = index + 1
        let second = input[nextIndex]

        if first > second then
            let input[index] = second
            let input[nextIndex] = first
            let swoped = true
            ()
    ()

    if swoped then
        bubblesort(input)
    else
        input