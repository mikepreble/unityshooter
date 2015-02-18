var scoreBoard: GUIText;
var score: int;

function Update() {
    var scoreText: String = "Score: " + score.ToString();
    scoreBoard.text = scoreText;
}
