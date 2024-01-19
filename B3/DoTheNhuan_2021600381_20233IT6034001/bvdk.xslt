<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">
		<html>
			<head>
				<title>Benh Vien Da Khoa</title>
			</head>
			<body>
				<div>
					<div>
						<h3>BENH VIEN DA KHOA</h3>
					</div>
				</div>
				<hr/>
				<xsl:for-each select="BVDK/Khoa">
					<div border="1" class="">
						<div>
							<div>
								<h3>DANH SACH BENH NHAN</h3>
							</div>
							<div>
								<p>
									Khoa: <xsl:value-of select="TenKhoa"/>
								</p>
							</div>
						</div>

						<table border="1" cellpadding="10">
							<thead>
								<tr>
									<th>STT</th>
									<th>Ho ten</th>
									<th>Ngay nhap vien</th>
									<th>So ngay dieu tri</th>
									<th>So tien phai tra</th>
								</tr>
							</thead>
							<tbody>
								<xsl:for-each select="PhongDieuTri">
									<xsl:for-each select="Phong/BenhNhan">
										<tr>
											<td>
												<xsl:value-of select="position()"/>
											</td>
											<td>
												<xsl:value-of select="HoTen"/>
											</td>
											<td>
												<xsl:value-of select="NgayNhapVien"/>
											</td>
											<td>
												<xsl:value-of select="SoNgayNamVien"/>
											</td>
											<td>
												<xsl:value-of select="SoNgayNamVien*15000"/>
											</td>
										</tr>
									</xsl:for-each>
								</xsl:for-each>
							</tbody>
						</table>
					</div>
				</xsl:for-each>

			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
