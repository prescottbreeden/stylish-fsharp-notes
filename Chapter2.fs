namespace StylishFsharp

open System

module MilesChains =
    type MilesChains = MilesChains of wholeMiles : int * chains : int
    let fromMilesChains(wholeMiles: int, chains: int) =
        if wholeMiles < 0 then
            raise <| ArgumentOutOfRangeException(
                "wholeMiles",
                "Must be >=0"
            )
        if chains < 0 || chains >= 80 then
            raise <| ArgumentOutOfRangeException(
                "chains",
                "Must be >=0 and < 80"
            )
        MilesChains(wholeMiles, chains)

    let toDecimalMiles (MilesChains(wholeMiles, chains)) : float =
        (float wholeMiles) + ((float chains) / 80.)

module MilesYards =
    // original version -- can be improved
    let convertMilesYards (milesPointYards : float) : float =
        let wholeMiles = milesPointYards |> floor
        let fraction = milesPointYards - float(wholeMiles)
        wholeMiles + (fraction / 0.1760)

    // type MilesYards = private MilesYards of wholeMiles : int * yards : int
    type MilesYards = MilesYards of wholeMiles : int * yards : int

    let fromMilesPointYards (milesPointYards : float) : MilesYards =
        let wholeMiles = milesPointYards |> floor |> int
        let fraction = milesPointYards - float(wholeMiles)
        if fraction > 0.1759 || fraction < 0. then
            raise <| ArgumentOutOfRangeException(
                "milesPointYards",
                "Fractional part must be >=0 and <= 0.1759"
            )
        let yards = fraction * 10_000. |> round |> int
        MilesYards(wholeMiles, yards)

    // let toDecimalMiles (milesYards: MilesYards) : float =
    //     match milesYards with
    //     | MilesYards(wholeMiles, yards) -> (float wholeMiles) + ((float yards) / 1760.)

    // destructure the arguments to avoid uneccessary match case
    let toDecimalMiles (MilesYards(wholeMiles, yards)) : float =
        (float wholeMiles) + ((float yards) / 1760.)

    // remove float bracketting
    // let private (~~) = float
    // let toDecimalMiles (MilesYards(wholeMiles, yards)) : float =
    //     ~~wholeMiles + (~~yards / 1760.)