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
      <Delta/>
    </section>
  </div>
</template>

<script>
import Hero from './components/Hero.vue';
import Delta from './components/Delta.vue';
import MenusNav from './components/MenusNav.vue';
import '@/assets/main.css';

export default {
  name: 'App',
  components: {
    MenusNav,
    Hero,
    Delta
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
  background-position: center center;
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

</style>
