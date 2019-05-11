<%@page import="java.util.ArrayList"%>
<%@page import="dominio.Funcao"%>
<%@page import="persistencia.FuncaoBD"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Lista de Funções</title>
    </head>
    <body>
        <h1>Lista de funções</h1>
        
        <%
            ArrayList<Funcao> funcoes = FuncaoBD.listar();
            
            for(int i = 0; i < funcoes.size(); i++){
                Funcao cadaFuncao = funcoes.get(i);
                out.println(cadaFuncao.getDescricao());
            }
        %>
    </body>
</html>
