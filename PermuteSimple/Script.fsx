// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "Permutation.fs"
open PermuteSimple

let seqs = generateFactoradic 23
//
for s in seqs do
    printfn "%A" s

