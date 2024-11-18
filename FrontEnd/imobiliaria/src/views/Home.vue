<template>
  <div>
    <header class="Nav__header">
      <div class="hideNavBar">
        <NavBar />
      </div>
      <div class="ShowNavBar">
        <MobileNavBar />
      </div>
    </header>

    <RouterView />
    <section class="Hero__bg">
      <Hero />
    </section>

    <section class="Delta">
      <Delta />
    </section>
  </div>
</template>

<script>
import Hero from '@/components/Hero.vue';
import Delta from '@/components/Delta.vue';
import NavBar from '@/components/NavBar.vue';
import '@/assets/main.css';
import MobileNavBar from '@/components/MobileNavBar.vue';

export default {
  name: 'Home',
  components: {
    Hero,
    Delta,
    NavBar,
    MobileNavBar
  },
  mounted() {
    // Script Menus
    const navMenu = document.getElementById("navMenu");
    const navToggle = document.getElementById("navToggle");

    if (navToggle) {
      navToggle.addEventListener("click", () => {
        navMenu.classList.toggle("show");
      });
    }
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
  margin: 0;
  padding: 0;
  font-family: Arial, sans-serif;
}

a {
  text-decoration: none;
}

.Nav__header {
  margin: 0;
  padding: 0;
}

.Hero__bg {
  position: relative;
  width: 100%;
  height: 450px;
  background: url('@/Images/bg.png') no-repeat center center;
  background-size: cover;
  display: flex;
  align-items: center;
  justify-content: center;
}

.Hero__bg::before {
  content: "";
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.4);
  z-index: 1;
}

.Hero__bg>* {
  position: relative;
  z-index: 2;
}

.Delta {
  background-color: #C1B49C;
  width: 100%;
  height: 300px;
  color: #FFF;
  padding-inline: 10rem;
  padding-top: 2.5rem;
}

@media (max-width: 1280px) {
  .Delta {
    background-color: #C1B49C;
    width: 100%;
    height: 700px;
    color: #FFF;
    padding-inline: 12rem;
    padding-top: 2.5rem;
  }

  .hideNavBar {
    display: none;
  }

  .ShowNavBar {
    display: block;
  }
}

@media (min-width: 1280px) {
  .hideNavBar {
    display: block;
  }

  .ShowNavBar {
    display: none;
  }
}

@media (max-width: 768px) {
  .Delta {
    background-color: #C1B49C;
    width: 100%;
    height: 900px;
    color: #FFF;
    padding-inline: 0;
    padding-top: 2.5rem;
  }
}
</style>
