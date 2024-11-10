<template>
  <div>
    <header class="Nav__header">
      <nav class="NavBar">
        <MenusNav />
        <ul class="Nav__actions">
          <li class="li__Home">
            <RouterLink to="/" class="Anunce__Bnt">Anunciar Gratis</RouterLink>
            <RouterLink to="/" class="Entry__Bnt">Entrar</RouterLink>
          </li>
        </ul>
      </nav>
    </header>

    <RouterView />
    <section class="Hero__bg">
      <Hero />
    </section>

    <section class="Delta">
      <p class="Delta__container__tittle">Acompanhamops você a cada passo</p>
      <div class="Delta__container">
        <div class="Delta__container__box">
          <p class="Delta__container__box__tittle">Busca clara e rápida</p>
          <p class="Delta__container__box__text">Pensamos em nossos filtros e mapas para simplificar sua experiência em
            nosso portal.</p>
        </div>
        <div class="Delta__container__box">
          <p class="Delta__container__box__tittle">Você tem sua própria seção</p>
          <p class="Delta__container__box__text">Acesse com facilidade e segurança os avisos de contato, favoritos,
            notas que você criou e muito mais.</p>
        </div>
        <div class="Delta__container__box">
          <p class="Delta__container__box__tittle">Variedade de anunciantes</p>
          <p class="Delta__container__box__text">Corretores de imóveis e proprietários diretos de todo o país oferecem
            as melhores opções de imóveis para você.</p>
        </div>
        <div class="Delta__container__box">
          <p class="Delta__container__box__tittle">Somos o Casa Mineira!</p>
          <p class="Delta__container__box__text">39 anos no mercado e um milhão de imóveis oferecidos nos apoiam na
            busca pela sua casa.</p>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import Hero from './components/Hero.vue';
import MenusNav from './components/MenusNav.vue';
import '@/assets/main.css';

export default {
  name: 'App',
  components: {
    MenusNav,
    Hero
  }
};
</script>


<style scoped>
*,
*::before,
*::after {
  box-sizing: border-box;
}

body {
  margin-inline: 10rem;
  margin: 0;
}

a {
  text-decoration: none;
}

.Nav__header {
  margin: 0;
  padding: 0;
}

.NavBar {
  display: flex;
  justify-content: space-between;
  padding-inline: 15rem;
  align-items: center;
  height: 60px;
  max-width: 100%;
  margin: 0 auto;
  width: 100%;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}


.Nav__actions {
  display: flex;
  gap: 20px;
  list-style: none;
  padding: 0;
  margin: 0;
}

.li__Home {
  display: flex;
  gap: 20px;
}

.Anunce__Bnt {
  background-color: transparent;
  border: none;
  color: black;
  padding: 0.90rem 1.5rem;
  text-align: center;
  text-decoration: none;
  font-size: 12px;
  cursor: pointer;
  border-radius: 10px;
  transition: background-color 0.3s;
}

.Anunce__Bnt:hover {
  background-color: #505050;
  color: #FFF;
}

.Entry__Bnt {
  background-color: #8CB9C5;
  border: none;
  color: white;
  padding: 0.90rem 1.5rem;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 12px;
  cursor: pointer;
  border-radius: 10px;
  transition: background-color 0.3s;
}

.Entry__Bnt:hover {
  background-color: #59808b;
}

.Hero__bg {
  width: 100%;
  height: 450px;
  background: url('@/Images/bg.png');
  background-repeat: no-repeat;
  background-size: cover;
  display: flex;
  align-items: center;
  justify-content: center;
}

.Delta {
  background-color: #C1B49C;
  width: 100%;
  height: 300px;
  color: #FFF;
  padding-inline: 12rem;
  padding-top: 2.5rem;
}

.Delta__container {
  display: flex;
  position: relative;
  -webkit-box-pack: justify;
  justify-content: space-between;
  top: 29px;
  max-width: 1600px;
}

.Delta__container__box {
  display: flex;
  flex-direction: column;
  -webkit-box-align: center;
  align-items: center;
  width: 300px;
  height: 133px;
  background: rgb(255, 255, 255);
  border-radius: 12px;
  text-align: center;
  margin-right: 40px;
  color: #000;
  padding-top: 10px;
}

.Delta__container__box__tittle {
  font-weight: 600;
  font-size: 20px;
  position: relative;
  top: 20px;
}

.Delta__container__box__text {
  font-weight: 500;
  font-size: 12px;
  position: relative;
  top: 20px;
}

.Delta__container__tittle {
  font-weight: 600;
  font-size: 20px;
  position: relative;
  top: -15px;
}
</style>
