<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:x="http://tempuri.org/MonHoc.xsd"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">
		<html>
			<head>
				<title>Danh Sach Mon Hoc</title>
			</head>
			<body>

				<table border="1">
					<thead>
						<tr>
							<th>MaMh</th>
							<th>TenMh</th>
							<th>SoGio</th>
						</tr>
					</thead>
					<tbody>
						<xsl:for-each select="x:DSMH/x:MonHoc">
							<xsl:if test="x:SoGio>=40">
								<tr>
									<td>
										<xsl:value-of select="@MaMh"></xsl:value-of>
									</td>
									<td>
										<xsl:value-of select="x:TenMh"></xsl:value-of>
									</td>
									<td>
										<xsl:value-of select="x:SoGio"></xsl:value-of>
									</td>
								</tr>

							</xsl:if>
						</xsl:for-each>
					</tbody>
				</table>



			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
