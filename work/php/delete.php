<?php

include('./database_connection/db_conn.php');

$item  = $_GET["item"] ?? null;
$id    = $_POST["id"] ?? null;
$label = $_POST["label"] ?? null;
$type  = $_POST["type"] ?? null;
$delete  = $_POST["delete"] ?? null;

$fetch = "SELECT * FROM tech";
$result = mysqli_query($conn, $fetch);
$rows = mysqli_fetch_all($result, MYSQLI_ASSOC);

if($item){
  $sql = "SELECT * FROM tech WHERE id = '$item' ";
  $result = mysqli_query($conn, $sql);
  $results = mysqli_fetch_all($result, MYSQLI_ASSOC);
}

if($delete){
  $query = "DELETE FROM tech WHERE id = '$id' ";
  mysqli_query($conn, $query);
  header("Location: " . $_SERVER['PHP_SELF'] );
}

 ?>

 <?php
  include('./view/header.php');
  include('./view/nav.php');
 ?>

<div style="text-align: center; padding:15px; margin-left: auto; margin-right:auto;">

  <h2>Delete a row from the table</h2>

  <form>
    <select name="item" onchange="this.form.submit()">
        <option value="-1">Select item</option>

        <?php foreach ($rows as $row){ ?>
            <option value="<?= $row["id"] ?>"><?= "(" . $row["id"]. ") " . $row["label"] ?></option>
        <?php } ?>

    </select>
</form>

<?php if ($results ?? null){ ?>
  <?php foreach($results as $result){ ?>
    <form method="post">
    <fieldset>
        <legend>Delete</legend>
        <p>
            <label>Id:
                <input type="text" readonly="readonly" name="id" value="<?= $result["id"] ?>">
            </label>
        </p>
        <p>
            <label>Label:
                <input type="text" name="label" value="<?= $result["label"] ?>">
            </label>
        </p>
        <p>
            <label>Type:
                <input type="text" name="type" value="<?= $result["type"] ?>">
            </label>
        </p>
        <p>
            <input type="submit" name="delete" value="Delete">
        </p>
    </fieldset>
</form>

<?php } ?>
<?php } ?>

<?php if ($rows ?? null) { ?>
    <table>
        <tr>
            <th>ID</th>
            <th>Label</th>
            <th>Type</th>
        </tr>

    <?php foreach ($rows as $row) { ?>
        <tr>
            <td><?= $row["id"] ?></td>
            <td><?= $row["label"] ?></td>
            <td><?= $row["type"] ?></td>
        </tr>
    <?php } ?>

    </table>
<?php } ?>

</div>

 <?php include('./view/footer.php'); ?>
