// Learn more about F# at http://fsharp.org
open StylishFsharp
open System

[<EntryPoint>]
let main argv =
    printfn "==========================="

    let decimalMiles = 1.0880 |> MilesYards.convertMilesYards
    printfn "Decimal miles for %f: %f" 1.0880 decimalMiles

    let badData = 1.1760 |> MilesYards.convertMilesYards
    printfn "Decimal miles for %f: %f" 1.1760 badData

    let refactored =
        1.0880 
        |> MilesYards.fromMilesPointYards 
        |> MilesYards.toDecimalMiles
        |> printfn "Miles Yards in Decimal Miles: %A"

    let milesChains = MilesChains.fromMilesChains(51, 23)
    milesChains
    |> MilesChains.toDecimalMiles
    |> printfn "Miles Chains in Decimal Miles: %A"

    printfn "==========================="

    let goldenRect = Shapes.Rectangle(1., 1.61803)
    printfn "%s" (Shapes.describe goldenRect)

    let circle = Shapes.Circle(3.14)
    printfn "%s" (Shapes.describe circle)

    let herMiddleName = Some "Ada"
    let myMiddleName = None
    let displayMiddleName (name: string option) =
        match name with
        | Some s -> s
        | None -> ""

    printfn ">>>%s<<<" (displayMiddleName myMiddleName)
    printfn ">>>%s<<<" (displayMiddleName herMiddleName)
    0 // return an integer exit code
