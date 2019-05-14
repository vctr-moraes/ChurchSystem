<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cadastro de Membros</title>
    </head>
    <body>
        <h1>Cadastrar um membro</h1>
        <form action="salvar.jsp" name="formCadastro" method="post">
            <label>Nome</label>
            <input type="text" name="nome" id="fnome" value=""> <br>
            <label>CPF</label>
            <input type="text" name="cpf" id="fcpf" value=""> <br>
            <label>Telefone</label>
            <input type="text" name="telefone" id="ftelefone" value=""> <br>
            <label>Data de Nascimento</label>
            <input type="text" name="dtNascimento" id="fdtNascimento" value=""> <br>
            <label>Batizado</label>
            <input type="radio" name="batizado" id="fbatizado" value="Sim">Sim
            <input type="radio" name="batizado" id="fbatizado" value="Não">Não <br><br>
            <input type="reset" name="limpar" value="Limpar">
            <input type="submit" name="salvar" value="Salvar">
        </form>
    </body>
</html>