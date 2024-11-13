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
/* Reset Global Styles */
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
  width: 100%;
}

.Hero__bg {
  position: relative;
  width: 100%;
  height: 500px;
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
  color: #FFF;
  padding-inline: 5rem;
  height: 700px;
  display: flex;
  justify-content: center;
  align-items: center;
}

@media (max-width: 1280px) {

  .Delta {
    height: 650px;
  }

  .hideNavBar {
    display: none;
  }

  .ShowNavBar {
    display: block;
  }
}

@media (max-width: 1024px) {

  .Hero__bg {
    height: 500px;
  }

  .Delta {
    height: 600px;
  }
}

@media (max-width: 768px) {

  .Hero__bg {
    height: 400px;
  }

  .Delta {
    height: 500px;
  }

  .hideNavBar {
    display: none;
  }

  .ShowNavBar {
    display: block;
  }
}

@media (max-width: 600px) {}

@media (max-width: 480px) {

  .Hero__bg {
    height: 400px;
  }

  .Delta {
    height: 1000px;
  }
}

@media (min-width: 481px) and (max-width: 768px) {
  .Delta {
    height: 900px;
  }
}

@media (min-width: 1280px) {

  .hideNavBar {
    display: block;
  }

  .ShowNavBar {
    display: none;
  }

  .Hero__bg {
    height: 450px;
  }
}
</style>
