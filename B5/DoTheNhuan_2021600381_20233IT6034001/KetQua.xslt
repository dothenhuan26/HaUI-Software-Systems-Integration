<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:x="http://tempuri.org/KetQua.xsd"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/x:DSKQ">
		<html>
			<head>
				<title>Danh Sach Ket Qua</title>
			</head>
			<body>

				<table border="1">

					<thead>
						<tr>
							<th>MaSv</th>
							<th>MaMh</th>
							<th>DiemThi</th>
						</tr>
					</thead>

					<tbody>
						<xsl:for-each select="x:SinhVien">
							<xsl:for-each select="x:MonHoc">
								<xsl:if test="x:DiemThi>=5">
									<tr>
										<td>
											<xsl:value-of select="../@MaSv" />
										</td>
										<td>
											<xsl:value-of select="x:MaMh" />
										</td>
										<td>
											<xsl:value-of select="x:DiemThi" />
										</td>
									</tr>
								</xsl:if>
							</xsl:for-each>
						</xsl:for-each>
					</tbody>

				</table>

			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
