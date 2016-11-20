
open System

let convertToBits n =
    let mutable mask = 0b00000001
    [for i in 0 .. 7 do
        let r =  n &&& mask
        mask <- mask <<< 1
        yield (r > 0)]
let convertToNumber (xs: bool list) =
    xs
    |> List.fold (fun (acc:int, counter) (x:bool)  ->
                        let n = (if x then 1 else 0)
                        let bitShiftedValue = (n <<< counter) 
                        ( acc ||| bitShiftedValue, counter + 1)) (0, 0)
    |> fst  
