open System
open System.Linq
open System.IO
open System.Text.Json

let text = File.ReadAllText("input.txt")

let json = JsonDocument.Parse(text).RootElement

let rec getValue (e: JsonElement): Int32 =
    if e.ValueKind = JsonValueKind.Object then
        if e.EnumerateObject().Any(fun v -> v.Value.ValueKind = JsonValueKind.String && v.Value.GetString() = "red") then
            0
        else
            e.EnumerateObject().Select(fun v -> getValue(v.Value)).Sum()
    else if e.ValueKind = JsonValueKind.Array then
        e.EnumerateArray().Select(getValue).Sum()
    else if e.ValueKind = JsonValueKind.Number then
        e.GetInt32()
    else
        0

Console.WriteLine(getValue(json))
