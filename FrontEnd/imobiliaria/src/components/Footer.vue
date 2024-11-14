<template>
  <footer class="footer">
    <!-- Logo no topo do footer -->
    <div class="footer__logo-container">
      <img src="" alt="Logo Do Site" class="footer__logo" />
    </div>

    <!-- Seções do footer em colunas -->
    <div class="footer__sections">
      <div class="footer__section">
        <h3>Nome do site</h3>
        <ul>
          <li><a href="#">Buscar imóveis</a></li>
          <li>
            <RouterLink to="Anunciar">Anunciar</RouterLink>
          </li>
          <li><a href="#">Trabalhe conosco</a></li>
          <li><a href="#">Quem somos</a></li>
          <li><a href="#">Central de Ajuda</a></li>
          <li><a href="#">Mapa do site</a></li>
          <li><a href="#">Blog</a></li>
          <li><a href="#">Precificador</a></li>
          <li><a href="#">Condomínios</a></li>
          <li><a href="#">Ruas e avenidas</a></li>
          <li><a href="#">Pontos de interesse</a></li>
        </ul>
      </div>

      <div class="footer__section">
        <h3>Anunciantes</h3>
        <ul>
          <li><a href="#">Imobiliárias</a></li>
        </ul>
      </div>

      <div class="footer__section">
        <h3>Países</h3>
        <ul>
          <li>Argentina: <a href="#">Zonaprop</a></li>
          <li>Brasil: <a href="#">Imovelweb</a> · <a href="#">Wimoveis</a> · <a href="#">QuintoAndar</a></li>
          <li>Mexico: <a href="#">Inmuebles24</a> · <a href="#">Vivanuncios</a></li>
          <li>Perú: <a href="#">Urbania</a> · <a href="#">Adondevivir</a></li>
          <li>Ecuador: <a href="#">Plusvalía</a></li>
          <li>Panamá: <a href="#">Compreoalquile</a></li>
        </ul>
      </div>
    </div>

    <!-- Copyright no final -->
    <div class="footer__bottom">
      <span>© Copyright 2024 casamineira.com.br</span>
      <a href="#">Termos e condições de uso</a> | <a href="#">Aviso de Privacidade</a>
    </div>
  </footer>
</template>

<script>
export default {
  name: 'Footer'
}
</script>

<style scoped>
.footer {
  background-color: #f8f9fa;
  color: #333;
  padding: 2rem;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.footer__logo-container {
  margin-bottom: 1.5rem;
}

.footer__logo {
  width: 150px;
}

.footer__sections {
  display: flex;
  justify-content: space-around;
  width: 100%;
}

.footer__section {
  margin: 0 1rem;
  text-align: left;
}

.footer__section h3 {
  font-size: 1.1rem;
  margin-bottom: 0.5rem;
}

.footer__section ul {
  list-style: none;
  padding: 0;
}

.footer__section li {
  margin: 0.3rem 0;
}

.footer__section a {
  color: #007bff;
  text-decoration: none;
}

.footer__section a:hover {
  text-decoration: underline;
}

.footer__bottom {
  margin-top: 2rem;
  font-size: 0.9rem;
  text-align: center;
}

.footer__bottom a {
  color: #007bff;
  text-decoration: none;
}

.footer__bottom a:hover {
  text-decoration: underline;
}

@media (max-width: 768px) {
  .footer__sections {
    flex-direction: column;
    align-items: center;
  }

  .footer__section {
    margin-bottom: 1rem;
  }
}
</style>
