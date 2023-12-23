<!-- dirsearch.xsl -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="html" indent="yes" />

  <xsl:template match="/">
    <html>
      <head>
        <title>Whitenight Junior Pentester</title>
        <style>
          body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(to right, #8447f0, #5e2ca5); /* Purple gradient background */
            margin: 0;
            padding: 0;
            min-height: 100vh;
            display: flex;
            flex-direction: column;
            align-items: center;
          }
          header {
            background-color: #5e2ca5;
            color: #fff;
            text-align: center;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            margin-bottom: 20px;
          }
          h1 {
            font-size: 3em;
            margin-bottom: 10px;
            color: #fff;
          }
          table {
            border-collapse: collapse;
            width: 80%;
            margin: 20px;
            background-color: #fff;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
          }
          th, td {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 12px;
          }
          th {
            background-color: #5e2ca5;
            color: #fff;
          }
          a {
            color: #5e2ca5;
            text-decoration: none;
          }
          footer {
            background-color: #333;
            color: #fff;
            text-align: center;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            margin-top: 20px;
          }
        </style>
      </head>
      <body>
        <header>
          <h1>🕷️ Whitenight - Phantom Troupe 🌙</h1>
        </header>
        <table>
          <tr>
            <th>URL</th>
            <th>Status</th>
            <th>Content Length</th>
            <th>Content Type</th>
            <th>Redirect</th>
          </tr>
          <xsl:apply-templates select="//target"/>
        </table>
        <footer>
          <p>
            On a mission to uncover the secrets of the digital realm. 
            The quieter we are, the louder we hear. 
          </p>
        </footer>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="target">
    <tr>
      <td>
        <a href="{@url}">
          <xsl:value-of select="@url"/>
        </a>
      </td>
      <td><xsl:value-of select="status"/></td>
      <td><xsl:value-of select="contentLength"/></td>
      <td><xsl:value-of select="contentType"/></td>
      <td>
        <xsl:if test="redirect">
          <a href="{redirect}">
            <xsl:value-of select="redirect"/>
          </a>
        </xsl:if>
      </td>
    </tr>
  </xsl:template>

</xsl:stylesheet>

