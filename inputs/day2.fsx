open System
open System.IO
open System.Text.RegularExpressions

let lines = File.ReadAllLines(".\\inputs\\aoc_input_day2.txt")

let getGameNo (game: string) =
    let gameNo = game.Split ":"[0] |> fun(item) -> Regex.Replace(input = item, pattern = "Game ", replacement = "") |> int
    gameNo

let zeroIfEmpty (value: string) =
    let newval = if (String.IsNullOrEmpty(value)) then 0 else value |> int
    newval

let getRGB (game: string) =
    let red = Regex.Match(input = game, pattern = "(\\d+) red").Groups[1].Value |> zeroIfEmpty
    let green = Regex.Match(input = game, pattern = "(\\d+) green").Groups[1].Value |> zeroIfEmpty
    let blue = Regex.Match(input = game, pattern = "(\\d+) blue").Groups[1].Value |> zeroIfEmpty
    [red; green; blue]

let getGames (game: string) =
    let games = game.Split ";" |> Seq.toList
    games |> List.map(fun(item: string) -> item |> getRGB)


let bag = [12; 13; 14]

type Round = {
    gameNumber: int
    games: int list list
}

let mappedlines = 
    lines 
    |> Seq.map (fun (line: string) -> {gameNumber = getGameNo line; games = getGames line})

let isNotPossible (round: int list) =
    round[0] > bag[0] || round[1] > bag[1] || round[2] > bag[2]

let gameImpossible (game: int list list) = 
    game |> List.map(fun (round: int list) -> round |> isNotPossible) |> List.contains true

let validgames = mappedlines |> Seq.filter ( _.games >> gameImpossible >> not)

validgames |> Seq.map _.gameNumber |> Seq.sum