// ts2fable 0.7.1
module Fable.PopperJS.CreatePopper
open Fable.Core
open Browser.Types
open Fable.PopperJS.Enums
open Fable.PopperJS.Types
open Fable.Core.JsInterop

type Array<'T> = System.Collections.Generic.IList<'T>
type [<AllowNullLiteral>] PopperGeneratorArgs =
    abstract defaultModifiers: Array<Modifier<obj option, obj option>> option with get, set
    abstract defaultOptions: obj option with get, set
    
    

type PopperModifier() =
    let mutable modifier = createEmpty<Modifier<string,obj>>
    
    member this.withName(name) =
        modifier.name <- name
        this
    member this.withEnabled(enabled) =
        modifier.enabled <- enabled
        this
    member this.withPhase(phase) =
        modifier.phase <- phase
        this
    
    member this.withRequires(requires) =
        modifier.requires <- Some requires
        this
    
    member this.withRequiresIfExists(requiresIfExists) =
        modifier.requiresIfExists <- Some requiresIfExists
        this
    
    member this.withFn(fn) =
        modifier.fn <- fn
        this
        
    member this.withEffect(effect) =
        modifier.effect <- Some effect
        this
    
    member this.withOptions(options) =
        modifier.options <- Some options
        this
    
    member this.withData(data) =
        modifier.data <- Some data
        this
        
    member this.Finalize() = modifier

type PopperOptions() =
    
    let mutable options = createEmpty<OptionsGeneric<Modifier<string,obj>>>
    
    member this.withPlacement(p: Placement) =
        options.placement <- p
        this
    
    member this.withModifiers(m)=
        options.modifiers <- m
        this
        
    member this.withAddedModifier(m: PopperModifier)=
        match options.modifiers with
        | Some _ -> options.modifiers.Value.Add(m.Finalize())
        | None -> options.modifiers <- Some [|m.Finalize()|]
        this
    
    member  this.withStrategy(s)=
        options.strategy <- s
        this
    
    member  this.withOnFirstUpdate(f)=
        options.onFirstUpdate <- f
        this
    
    member this.Finalize() = options


type Popper() =
    [<Import("createPopper","@popperjs/core")>]
    static member createPopper(reference: Element, popper: HTMLElement, ?options:OptionsGeneric<Modifier<string,obj>>): Instance = jsNative
    
    
[<Import("createPopper","@popperjs/core")>]
let createPopper(reference: Element, popper: HTMLElement, options: obj): Instance = jsNative

type [<AllowNullLiteral>] IExports =
    abstract popperGenerator: ?generatorOptions: PopperGeneratorArgs -> (U2<Element, VirtualElement> -> HTMLElement -> obj -> Instance)

