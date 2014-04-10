namespace PermuteSimple

open System
open System.Collections.Generic
open System.Linq
open Microsoft.FSharp.Linq

[<AutoOpen>]
module PermutationsModule =
    let fact (n : int64) =
        let rec factRec n acc =
            if n <= 1L then acc
            else
                factRec (n - 1L) (acc * n)

        factRec n 1L

    let nextNum (num : List<int>) =
        // find the "unsaturated" postion
        let zeroOut (num : List<int>) curPos = [0..curPos] |> List.map(fun i -> num.[i] <- 0)
        let rec addOneRec (num : List<int>) curPos =
            if num.[curPos] < curPos 
            then 
                num.[curPos] <- num.[curPos] + 1
                zeroOut num (curPos - 1) |> ignore
            else
                addOneRec num (curPos + 1)

        addOneRec num 0
            
    /// Generate factoradic numbers of length "len"
    /// Include 1! and 0 last digit
    /// http://en.wikipedia.org/wiki/Factorial_number_system
    let generateFactoradic len =
        
        let maxReached (num : List<int>) len =
            if num.[len - 1] < len - 1 then false
            else
                num |> Seq.mapi (fun i n -> i = n) |> Seq.fold (fun st b -> st && b ) true

        // stores the current number
        let cur = List<int>()
        cur.AddRange(Array.zeroCreate len)

        // first two numbers: 0 and 1!

        [|
            let yld = cur.ToArray()
            yield yld

            while not (maxReached cur len) do
                nextNum cur
                let yld = cur.ToArray()
                yield yld.Reverse().ToArray()               
        |]
    
    /// all permutations [0..n-1]
    let permute n =
        let factors = generateFactoradic n

        [|
            for factor in factors do
                let ordered = Enumerable.Range(0, n).ToList()
                yield
                    [| 
                        for f in factor do
                            yield ordered.[f]
                            ordered.RemoveAt(f)
                    |]
        |]
                  