<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="java.util.Date"%>
<%@page import="java.text.SimpleDateFormat"%>
<%@page import="dominio.Doacao"%>
<%@page import="persistencia.DoacaoBD"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cadastrar Nova Doação</title>
    </head>
    <body>
        <%
            String membro = request.getParameter("membro");
            String quantia = request.getParameter("quantia");
            String tipo = request.getParameter("tipo");
            String data = request.getParameter("data");
            
            SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyyy");
            Date dataDoacao = formato.parse(data);
            
            float dizimo = Float.valueOf(quantia).floatValue();
            
            Doacao doacao = new Doacao();
            
            //doacao.setMembro(membro);
            doacao.setQuantia(dizimo);
            //doacao.setTipo(tipo);
            doacao.setData(dataDoacao);
            
            DoacaoBD.inserir(doacao);
        %>
        
        <br>
        
        <!--Teste de impressão na tela -->
        Nome:                <%=dizimo%> <br>
        CPF:                 <%=dataDoacao%> <br>
        
        <br>
        
        <p>Doação cadastrada com sucesso!!!</p>
    </body>
</html>
