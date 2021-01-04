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

module DeliveryService =
    type BillingDetails = {
        name : string
        billing : string
        delivery : string option }

    let addressForPackage (details : BillingDetails) =
        let address =
            match details.delivery with
            | Some s -> s
            | None -> details.billing
        sprintf "%s\n%s" details.name address

    let myOrder = {
        name = "Kit Eason"
        billing = "112 Fibonacci Street\nErehwon\n35813"
        delivery = None }

    let herOrder = {
        name = "Freya Breeden"
        billing = "314 Pi Avenue\nErehwon\n15926"
        delivery = Some "16 Planck Parkway\nErewhon\n62291" }