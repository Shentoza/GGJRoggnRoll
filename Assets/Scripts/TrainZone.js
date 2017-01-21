#pragma strict

static var trainzone = false;

function OnTriggerEnter(Collider) {
    trainzone = true;

    print("Zug kann bewegt werden");
}