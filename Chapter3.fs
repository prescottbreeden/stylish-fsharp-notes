namespace StylishFsharp

open System

module Shapes =
    type Shape<'T> =
    | Square of height : 'T
    | Rectangle of height : 'T * width : 'T
    | Circle of radius : 'T

    let describe (shape : Shape<float>) =
        match shape with
        | Square h -> sprintf "Sqyare of height %f" h
        | Rectangle(h, w) -> sprintf "Rectangle %f x %f" h w
        | Circle r -> sprintf "Circle of radius %f" r
