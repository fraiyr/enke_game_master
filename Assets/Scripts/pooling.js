var otherBack: GameObject;
var bats: GameObject;

function OnTriggerEnter2D (other: Collider2D) {

    //randomly choose between objects to spawn
    //optional
    var spawnBats: int = Random.Range(0, 2);
    if(spawnBats == 0){
        bats.SetActive(false);
    }

    if(spawnBats == 1) {
        bats.SetActive(true);
    }

    otherBack.transform.position.x = otherBack.transform.position.position.x + (72);
    otherBack.transform.position.y = 0;
}