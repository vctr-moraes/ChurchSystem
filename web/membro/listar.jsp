<%@page import="persistencia.MembroBD"%>
<%@page import="java.util.ArrayList"%>
<%@page import="dominio.Membro"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Lista de Membros</title>
    </head>
    <body>
        <h1>Lista de membros</h1>
        
        <%
            ArrayList<Membro> membros = MembroBD.listar();
            
            for(int i = 0; i < membros.size(); i++){
                Membro cadaMembro = membros.get(i);
                out.println(cadaMembro.getMatricula());
                out.println(cadaMembro.getNome());
                out.println(cadaMembro.getCpf());
                out.println(cadaMembro.getDataNascimento());
                out.println(cadaMembro.getTelefone());
                out.println(cadaMembro.getDataMatricula());
            }
        %>
    </body>
</html>
