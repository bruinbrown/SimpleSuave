// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.


open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open System.Net

[<EntryPoint>]
let main [| port |] = 
    
    let config = { defaultConfig with bindings = [ HttpBinding.mk HTTP IPAddress.Loopback (uint16 port) ] }


    let app =
        choose
            [ GET >=> path "/hello" >=> OK "Hello DevSouthCoast"
              pathScan "/hello/%s" (fun name -> OK("Hello " + name)) ]


    startWebServer config app

    0

    
