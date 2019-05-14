<%@page import="persistencia.DoacaoBD"%>

<%
    String codigo = request.getParameter("codigo");
    
    int cod;
    cod = Integer.parseInt(codigo);
    
    DoacaoBD.excluir(cod);
    
    response.sendRedirect("doacao.jsp");
%>