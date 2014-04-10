// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open PermuteSimple

[<EntryPoint>]
let main argv = 
    let seqs = permute 3

    for s in seqs do
        printfn "%A" s
    
    0 // return an integer exit code
