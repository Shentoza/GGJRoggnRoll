#pragma strict

function Update () {
    if(TrainZone.trainzone == true){
        GetComponent.<Animation>().Play();
    }
}
