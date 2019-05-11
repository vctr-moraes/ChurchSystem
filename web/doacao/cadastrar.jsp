<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cadastrar Nova Doação</title>
    </head>
    <body>
        <h1>Cadastrar uma nova doação</h1>
        <form action="salvar.jsp" name="formCadastro" method="post">
            <label>Membro</label>
            <input type="text" name="membro" id="fmembro" value=""> <br>
            <label>Quantia</label>
            <input type="number" name="quantia" id="fquantia" value=""> <br>
            <label>Tipo</label>
            <input type="radio" name="tipo" id="ftipo" value="Dízimo">Dízimo
            <input type="radio" name="tipo" id="ftipo" value="Doação">Doação <br>
            <label>Data</label>
            <input type="text" name="data" id="fdata" value=""> <br><br>
            <input type="reset" name="limpar" value="Limpar">
            <input type="submit" name="salvar" value="Salvar">
        </form>
    </body>
</html>
