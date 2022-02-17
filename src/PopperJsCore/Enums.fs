// ts2fable 0.7.1
module rec PopperJsCore.Enums
open System
open Fable.Core
open Fable.Core.JS

type Array<'T> = System.Collections.Generic.IList<'T>

let [<Import("top","@popperjs/core/lib/enums")>] top: string = jsNative
let [<Import("bottom","@popperjs/core/lib/enums")>] bottom: string = jsNative
let [<Import("right","@popperjs/core/lib/enums")>] right: string = jsNative
let [<Import("left","@popperjs/core/lib/enums")>] left: string = jsNative
let [<Import("auto","@popperjs/core/lib/enums")>] auto: string = jsNative
let [<Import("basePlacements","@popperjs/core/lib/enums")>] basePlacements: Array<BasePlacement> = jsNative
let [<Import("start","@popperjs/core/lib/enums")>] start: string = jsNative
let [<Import("end","@popperjs/core/lib/enums")>] ``end``: string = jsNative
let [<Import("clippingParents","@popperjs/core/lib/enums")>] clippingParents: string = jsNative
let [<Import("viewport","@popperjs/core/lib/enums")>] viewport: string = jsNative
let [<Import("popper","@popperjs/core/lib/enums")>] popper: string = jsNative
let [<Import("reference","@popperjs/core/lib/enums")>] reference: string = jsNative
let [<Import("variationPlacements","@popperjs/core/lib/enums")>] variationPlacements: Array<VariationPlacement> = jsNative
let [<Import("placements","@popperjs/core/lib/enums")>] placements: Array<Placement> = jsNative
let [<Import("beforeRead","@popperjs/core/lib/enums")>] beforeRead: string = jsNative
let [<Import("read","@popperjs/core/lib/enums")>] read: string = jsNative
let [<Import("afterRead","@popperjs/core/lib/enums")>] afterRead: string = jsNative
let [<Import("beforeMain","@popperjs/core/lib/enums")>] beforeMain: string = jsNative
let [<Import("main","@popperjs/core/lib/enums")>] main: string = jsNative
let [<Import("afterMain","@popperjs/core/lib/enums")>] afterMain: string = jsNative
let [<Import("beforeWrite","@popperjs/core/lib/enums")>] beforeWrite: string = jsNative
let [<Import("write","@popperjs/core/lib/enums")>] write: string = jsNative
let [<Import("afterWrite","@popperjs/core/lib/enums")>] afterWrite: string = jsNative
let [<Import("modifierPhases","@popperjs/core/lib/enums")>] modifierPhases: Array<ModifierPhases> = jsNative

type BasePlacement =
    obj

type Variation =
    obj

type Boundary =
    U3<Element, Array<Element>, obj>

type RootBoundary =
    U2<obj, string>

type Context =
    obj

type [<StringEnum>] [<RequireQualifiedAccess>] VariationPlacement =
    | [<CompiledName "top-start">] TopStart
    | [<CompiledName "top-end">] TopEnd
    | [<CompiledName "bottom-start">] BottomStart
    | [<CompiledName "bottom-end">] BottomEnd
    | [<CompiledName "right-start">] RightStart
    | [<CompiledName "right-end">] RightEnd
    | [<CompiledName "left-start">] LeftStart
    | [<CompiledName "left-end">] LeftEnd

type [<StringEnum>] [<RequireQualifiedAccess>] AutoPlacement =
    | Auto
    | [<CompiledName "auto-start">] AutoStart
    | [<CompiledName "auto-end">] AutoEnd

type ComputedPlacement =
    U2<VariationPlacement, BasePlacement>

type Placement =
    U3<AutoPlacement, BasePlacement, VariationPlacement>

type ModifierPhases =
    obj
