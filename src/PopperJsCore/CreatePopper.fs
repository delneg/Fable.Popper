// ts2fable 0.7.1
module rec PopperJsCore.CreatePopper
open System
open Fable.Core
open Fable.Core.JS
open Browser.Types

type Array<'T> = System.Collections.Generic.IList<'T>

let [<Import("createPopper","@popperjs/core/lib/createPopper")>] createPopper: (U2<Element, VirtualElement> -> HTMLElement -> obj -> Instance) = jsNative

type [<AllowNullLiteral>] IExports =
    abstract popperGenerator: ?generatorOptions: PopperGeneratorArgs -> (U2<Element, VirtualElement> -> HTMLElement -> obj -> Instance)

type [<AllowNullLiteral>] PopperGeneratorArgs =
    abstract defaultModifiers: Array<Modifier<obj option, obj option>> option with get, set
    abstract defaultOptions: obj option with get, set
