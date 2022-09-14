module Expressive.Program

open System
open Glutinum.Express
open Glutinum.ExpressServeStaticCore
open Fable.Core.JsInterop

let bodyParser =
    importDefault<Glutinum.BodyParser.BodyParser.IExports> "body-parser"

let app = express.express ()

app.``use`` (bodyParser.json ())

app.get ("/", (fun (req: Request) (res: Response) -> res.send {| message = "Hello Fable!" |} |> ignore))

[<EntryPoint>]
let main argv =
    app.listen (3000, "0.0.0.0", (fun _ -> printfn "Started app at 0.0.0.0:3000"))
    |> ignore

    0 // return an integer exit code
