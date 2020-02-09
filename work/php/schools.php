
    <?php include('./view/header.php');?>

    <div class="option">
      <select name="municipalities" onchange="clickme(this.value)">
        <option value="" disabled selected>Municipalities</option>
        <option value="Kristianstad" >Kristianstad</option>
        <option value="Hudiksvall">Hudiksvall</option>
        <option value="Lund">Lund</option>
        <option value="Stockholm">Stockholm</option>
      </select>

      <button id = "duckButton" type="button" onclick="show()">Hide Duck</button>
      <table id="container">
      </table>
    </div>

    <img id="duck" onclick="moveDuck()" src="img/duck.png" alt="duck picture">
	
	<?php include './view/footer.php'; ?>


