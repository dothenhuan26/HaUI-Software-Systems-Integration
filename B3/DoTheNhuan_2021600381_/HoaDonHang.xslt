<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">
		<hmtl>
			<head>
				<title>Phieu mua hang</title>
			</head>
			<body>
				<h1>PHIEU MUA HANG</h1>
				<h3>
					Hoa don: <xsl:value-of select="DS/HoaDon/MaHD"/>
				</h3>
				<h3>
					Ngay ban: <xsl:value-of select="DS/HoaDon/NgayBan"/>
				</h3>
				<h3>
					Loai hang: <xsl:value-of select="DS/HoaDon/LoaiHang/@TenLoai"/>
				</h3>
				<table border="1">
					<tr>
						<th>Ma hang</th>
						<th>Ten hang</th>
						<th>So luong</th>
						<th>Don gia</th>
						<th>Thanh tien</th>
					</tr>
					<!--<xsl:for-each select="DS/HoaDon/LoaiHang/Hang">
						<tr>
							<td>
								<xsl:value-of select="@MaHang"/>
							</td>
							<td>
								<xsl:value-of select="TenHang" />
							</td>
							<td>
								<xsl:value-of select="SoLuong"/>
							</td>
							<td>
								<xsl:value-of select="DonGia"/>
							</td>
							<td>
								<xsl:value-of select="SoLuong*DonGia"/>
							</td>
						</tr>
					</xsl:for-each>-->
					<xsl:apply-templates select="DS/HoaDon/LoaiHang/Hang"/>
				</table>
			</body>
		</hmtl>
	</xsl:template>

	<xsl:template match="DS/HoaDon/LoaiHang/Hang">
		<tr>
			<td>
				<xsl:value-of select="@MaHang"/>
			</td>
			<td>
				<xsl:value-of select="TenHang" />
			</td>
			<td>
				<xsl:value-of select="SoLuong"/>
			</td>
			<td>
				<xsl:value-of select="DonGia"/>
			</td>
			<td>
				<xsl:value-of select="SoLuong*DonGia"/>
			</td>
		</tr>
	</xsl:template>

</xsl:stylesheet>
