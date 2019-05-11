package org.apache.jsp.membro;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;
import java.util.Date;
import java.text.SimpleDateFormat;
import dominio.Membro;
import persistencia.MembroBD;

public final class salvar_jsp extends org.apache.jasper.runtime.HttpJspBase
    implements org.apache.jasper.runtime.JspSourceDependent {

  private static final JspFactory _jspxFactory = JspFactory.getDefaultFactory();

  private static java.util.List<String> _jspx_dependants;

  private org.glassfish.jsp.api.ResourceInjector _jspx_resourceInjector;

  public java.util.List<String> getDependants() {
    return _jspx_dependants;
  }

  public void _jspService(HttpServletRequest request, HttpServletResponse response)
        throws java.io.IOException, ServletException {

    PageContext pageContext = null;
    HttpSession session = null;
    ServletContext application = null;
    ServletConfig config = null;
    JspWriter out = null;
    Object page = this;
    JspWriter _jspx_out = null;
    PageContext _jspx_page_context = null;

    try {
      response.setContentType("text/html;charset=UTF-8");
      pageContext = _jspxFactory.getPageContext(this, request, response,
      			null, true, 8192, true);
      _jspx_page_context = pageContext;
      application = pageContext.getServletContext();
      config = pageContext.getServletConfig();
      session = pageContext.getSession();
      out = pageContext.getOut();
      _jspx_out = out;
      _jspx_resourceInjector = (org.glassfish.jsp.api.ResourceInjector) application.getAttribute("com.sun.appserv.jsp.resource.injector");

      out.write("\n");
      out.write("\n");
      out.write("\n");
      out.write("\n");
      out.write("\n");
      out.write("\n");
      out.write("<!DOCTYPE html>\n");
      out.write("<html>\n");
      out.write("    <head>\n");
      out.write("        <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n");
      out.write("        <title>Cadastro de Membros</title>\n");
      out.write("    </head>\n");
      out.write("    <body>\n");
      out.write("        ");

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
        
      out.write("\n");
      out.write("        \n");
      out.write("        <br>\n");
      out.write("        \n");
      out.write("        <!--Teste de impressão na tela -->\n");
      out.write("        Nome:                ");
      out.print(nome);
      out.write(" <br>\n");
      out.write("        CPF:                 ");
      out.print(cpf);
      out.write(" <br>\n");
      out.write("        Telefone:            ");
      out.print(telefone);
      out.write(" <br>\n");
      out.write("        Data de Nascimento:  ");
      out.print(dtNascimento);
      out.write(" <br>\n");
      out.write("        Teste Data:                ");
      out.print(formato.format(dtNascimento));
      out.write("\n");
      out.write("        Batizado:            ");
      out.print(batizado);
      out.write(" <br>\n");
      out.write("        \n");
      out.write("        <br>\n");
      out.write("        \n");
      out.write("        <p>Membro cadastrado com sucesso!!!</p>\n");
      out.write("    </body>\n");
      out.write("</html>\n");
    } catch (Throwable t) {
      if (!(t instanceof SkipPageException)){
        out = _jspx_out;
        if (out != null && out.getBufferSize() != 0)
          out.clearBuffer();
        if (_jspx_page_context != null) _jspx_page_context.handlePageException(t);
        else throw new ServletException(t);
      }
    } finally {
      _jspxFactory.releasePageContext(_jspx_page_context);
    }
  }
}
