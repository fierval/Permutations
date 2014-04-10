// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "Permutation.fs"
open PermuteSimple
open System

let seqs = generateFactoradic 1
//
for s in seqs do
    s |> Seq.iter (fun s -> Console.Write("{0} ", s))
    Console.WriteLine()


printfn "%i" (fact 5L)
printfn "%i" (fact 10L)
printfn "%i" (fact 0L)