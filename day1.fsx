open System
open System.IO
open System.Text.RegularExpressions

let lines = File.ReadAllLines(".\\inputs\\aoc_input_day1.txt")

let lines_list = Seq.toList lines

let calculate_calibration_code (item: string) =
    let newitem = Regex.Replace(item, "[^0-9 _]", "")
    let first = newitem.[0]
    let last = newitem |> Seq.last
    let calibration_code = string first + string last
    (calibration_code |> int);

let partonelist = lines_list |> List.map(fun (item: string) -> item |> calculate_calibration_code)
partonelist |> List.sum
// 56506

let wordToDigit (input: string) =
    match input with
    | "one" -> 1
    | "two" -> 2
    | "three" -> 3
    | "four" -> 4
    | "five" -> 5
    | "six" -> 6
    | "seven" -> 7
    | "eight" -> 8
    | "nine" -> 9
    | _ -> (int)input

let calculate_calibration_code_part2 (item: string) =

    let first = Regex.Match(item, @"\d|one|two|three|four|five|six|seven|eight|nine").Value
    let second = Regex.Match(item, @"\d|one|two|three|four|five|six|seven|eight|nine", RegexOptions.RightToLeft).Value
    let calibration_code = wordToDigit(first) * 10 + wordToDigit(second)
    calibration_code

let parttwolist = lines_list |> List.map(fun (item: string) -> item |> calculate_calibration_code_part2)
parttwolist |> List.sum
// 56017