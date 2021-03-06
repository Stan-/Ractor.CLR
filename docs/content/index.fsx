(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin"


(**
Ractor
===================

Install
------------------
<div class="row">
  <div class="span1"></div>
  <div class="span6">
    <div class="well well-small" id="nuget">
      The Ractor library can be <a href="https://nuget.org/packages/Ractor">installed from NuGet</a>:
      <pre>PM> Install-Package Ractor</pre>
    </div>
  </div>
  <div class="span1"></div>
</div>

Usage Example
-------

*)

#r "Ractor.dll"
#r "Ractor.Persistence.dll"

open System
open System.Text
open Ractor

let fredis = new Ractor("localhost")

let computation (input:string) : Async<unit> =
    async {
        Console.WriteLine("Hello, " + input)
    }

let greeter = fredis.CreateActor("greeter", computation)
// type annotations are required
let sameGreeter  = Ractor.GetActor<string, unit>("greeter")
greeter.Post("Greeter 1")
greeter.Post("Greeter 2")
greeter.Post("Greeter 3")
greeter.Post("Greeter 4")
greeter.Post("Greeter 5")

sameGreeter.Post("Greeter via instance from Ractor.GetActor")

// this will fail if computation returns not Async<unit>
"greeter" <-- "Greeter via operator"

()


(**
 
Contributing and copyright
--------------------------

The project is hosted on [GitHub][gh] where you can [report issues][issues], fork 
the project and submit pull requests. If you're adding new public API, please also 
consider adding [samples][content] that can be turned into a documentation. You might
also want to read [library design notes][readme] to understand how it works.


(c) Victor Baybekov 2014.
Licensed under the Apache License, Version 2.0 (the "License")


  [content]: https://github.com/buybackoff/Ractor.CLR/tree/master/docs/content
  [gh]: https://github.com/buybackoff/Ractor.CLR
  [issues]: https://github.com/buybackoff/Ractor.CLR/issues
  [readme]: https://github.com/buybackoff/Ractor.CLR/blob/master/README.md
  [license]: https://github.com/buybackoff/Ractor.CLR/blob/master/LICENSE.txt
*)
