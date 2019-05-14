<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="java.util.Date"%>
<%@page import="java.text.SimpleDateFormat"%>
<%@page import="dominio.Membro"%>
<%@page import="persistencia.MembroBD"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cadastro de Membros</title>
    </head>
    <body>
        <%
            String nome = request.getParameter("nome");
            String cpf = request.getParameter("cpf");
            String telefone = request.getParameter("telefone");
            String dtNascimento = request.getParameter("dtNascimento");
            String batizado = request.getParameter("batizado");

            //Convertendo string para data
            SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyyy");
            Date data = formato.parse(dtNascimento);

            //Convertendo string para boolean
            Boolean batizo = Boolean.getBoolean(batizado);

            Membro membro = new Membro();

            membro.setNome(nome);
            membro.setCpf(cpf);
            membro.setTelefone(telefone);
            membro.setDataNascimento(data);
            membro.setBatizado(batizo);

            MembroBD.inserir(membro);
        %>

        <br>

        <!--Teste de impressão na tela -->
        Nome:                <%=nome%> <br>
        CPF:                 <%=cpf%> <br>
        Telefone:            <%=telefone%> <br>
        Data de Nascimento:  <%=dtNascimento%> <br>
        Batizado:            <%=batizado%> <br>

        <br>

        <p>Membro cadastrado com sucesso!!!</p>
        <a href="../index.xhtml">Voltar</a>
    </body>
</html>
