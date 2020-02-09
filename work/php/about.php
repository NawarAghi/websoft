
<?php include './view/header.php'; ?>


<article>


<div class="about">
  <h1>About</h1>

  <img src="img/web.jpeg" width="450" alt="Web Development image">

  <p>This website is part of the course
     <a href="https://www.hkr.se/en/course/WD500F">Web Development</a>.
       at Kristianstad University</p>

</div>
<div class="content">
<h3>Content</h3>
<p>Section 01: Web application development</p>
<p>Section 02: HTML, CSS and JavaScript</p>
<p>Section 03: Client side JavaScript with AJAX</p>
<p>Section 04: Server side JavaScript with Node and Express</p>
<p>Section 05: PHP and databases with MySQL/MariaDB</p>
<p>Section 06: JavaScript and PHP frameworks</p>
<p>Section 07: ASP.NET and Model View Controller (MVC)</p>
<p>Section 08: Web application performance</p>
<p>Section 09: Web security and OWASP</p>
<p>Section 10: Project</p>

</div>
<button id = "duckButton" type="button" onclick="show()" style="float:right">Hide Duck</button>
<img id="duck" onclick="moveDuck()" src="img/duck.png" alt="duck picture" style="float:right">
</article>

<?php include './view/footer.php'; ?>


