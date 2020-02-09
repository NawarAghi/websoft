
    <?php include('./view/header.php');?>
    <div class="box">
      <div class="row">
        <div class="column">
          <a  href="#Italy" id="italian_flag_link"
              onclick="drawItalianFlag()" style ="width=100%">Italy</a>
        </div>
        <div class="column">
          <a  href="#Germany" id="german_flag_link"
              onclick="drawGermanFlag()" style ="width=100%">Germany</a>
        </div>
        <div class="column">
          <a href="#France" id="french_flag_link"
             onclick="drawFrenchFlag()" style ="width=100%">France</a>
        </div>
      </div>

      <div class="row">

        <div class="column">
          <div id="italian_flag" onclick="hideFlags('italian_flag')" style ="width=100%"></div>
        </div>
        <div class="column">
          <div id="german_flag" onclick="hideFlags('german_flag')" style ="width=100%"></div>
        </div>
        <div class="column">
          <div id="french_flag" onclick="hideFlags('french_flag')" style ="width=100%"></div>
        </div>

      </div>
    </div>

    <div class="duc">
      <button id = "duckButton" type="button" onclick="show()">Hide Duck</button>
      <img id="duck" onclick="moveDuck()" src="img/duck.png" alt="duck picture">
    </div>
	
	<?php include './view/footer.php'; ?>

 
