<%@page import="persistencia.FuncaoBD"%>

<%
    String codigo = request.getParameter("codigo");
    
    int cod;
    cod = Integer.parseInt(codigo);
    
    FuncaoBD.excluir(cod);
    
    response.sendRedirect("funcao.jsp");
%>