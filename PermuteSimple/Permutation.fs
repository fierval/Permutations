namespace PermuteSimple

open System
open System.Collections.Generic
open System.Linq
open Microsoft.FSharp.Linq

[<AutoOpen>]
module PermutationsModule =
    
    let addOne (num : List<int>) =
        // find the "unsaturated" postion
        let zeroOut (num : List<int>) curPos = [0..curPos] |> List.map(fun i -> num.[i] <- 0)
        let rec addOneRec (num : List<int>) curPos =
            if num.[curPos] < curPos 
            then 
                num.[curPos] <- num.[curPos] + 1
                zeroOut num (curPos - 1) |> ignore
            elif curPos = num.Count - 1
            then
                zeroOut num curPos |> ignore
                num.Add(1) |> ignore
            else
                addOneRec num (curPos + 1)

        addOneRec num 0
            
    /// Generate factoradic numbers of length "len"
    /// Include 1! and 0 last digit
    /// http://en.wikipedia.org/wiki/Factorial_number_system
    let generateFactoradic len =
            
        // stores the current number
        let cur = List<int>()
        cur.Add(0)

        // first two numbers: 0 and 1!

        [|
            let yld = cur.ToArray()
            yield yld.AsEnumerable()

            for i = 1 to len - 1 do
                addOne cur
                let yld = cur.ToArray()
                yield yld.Reverse()               
        |]
    