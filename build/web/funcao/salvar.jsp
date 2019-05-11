<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="dominio.Funcao"%>
<%@page import="persistencia.FuncaoBD"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cadastro de Função</title>
    </head>
    <body>
        <%
            String descricao = request.getParameter("descricao");
            
            Funcao funcao = new Funcao();
            
            funcao.setDescricao(descricao);
            
            FuncaoBD.inserir(funcao);
        %>
        
        <br>
        
        <!-- Teste de impressão na tela -->
        Descrição: <%=descricao%> <br>
        
        <p>Função cadastrada com sucesso!!!</p>
        <a href="../index.xhtml">Voltar</a>
    </body>
</html>
