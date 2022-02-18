// ts2fable 0.7.1
module PopperJsCore.CreatePopper
open System
open Fable.Core
open Fable.Core.JS
open Browser.Types
open PopperJsCore.Enums
open PopperJsCore.Types
type Array<'T> = System.Collections.Generic.IList<'T>
type [<AllowNullLiteral>] PopperGeneratorArgs =
    abstract defaultModifiers: Array<Modifier<obj option, obj option>> option with get, set
    abstract defaultOptions: obj option with get, set
    
    
    
    
    
    

type [<AllowNullLiteral>] PopperOptions() =
    
    interface OptionsGeneric<obj> with
        member val placement = Placement.Case2 BasePlacement.Bottom with get,set
        
        member val modifiers = [||] with get,set
        member val strategy = None with get,set
        member val onFirstUpdate = None with get,set
    
    
    [<Erase>]
    member this.withUpdatedPlacement(p: Placement)=
        (this :> OptionsGeneric<_>).placement <- p
        this
    
    member inline  this.withUpdatedModifiers(m)=
        (this :> OptionsGeneric<_>).modifiers <- m
        this
    
    member inline  this.withUpdatedStrategy(s)=
        (this :> OptionsGeneric<_>).strategy <- s
        this
    
    member inline  this.withUpdatedOnFirstUpdate(f)=
        (this :> OptionsGeneric<_>).onFirstUpdate <- f
        this
    
    
    
type Popper() =
    [<Import("createPopper","@popperjs/core")>]
    static member createPopper(reference: Element, popper: HTMLElement, ?options:OptionsGeneric<obj>): Instance = jsNative
    
[<Import("createPopper","@popperjs/core")>]
let createPopper(reference: Element, popper: HTMLElement, options: PopperOptions): Instance = jsNative
[<Import("createPopper","@popperjs/core")>]
let createPopper2(reference: Element, popper: HTMLElement, options: OptionsRecordGeneric option): Instance = jsNative


type [<AllowNullLiteral>] IExports =
    abstract popperGenerator: ?generatorOptions: PopperGeneratorArgs -> (U2<Element, VirtualElement> -> HTMLElement -> obj -> Instance)

