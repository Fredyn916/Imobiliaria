<template>
  <div>
    <RouterView />

    <section class="Hero__bg">
      <Hero />
    </section>

    <section class="Delta">
      <Delta />
    </section>

    <section class="Echo">
      <Echo />
    </section>

    <section class="Alpha">
      <Alpha />
    </section>

  </div>
</template>


<script>
import Hero from '@/components/Hero.vue';
import Delta from '@/components/Delta.vue';
import Echo from '@/components/Echo.vue';
import Alpha from '@/components/Alpha.vue';
import NavBar from '@/components/NavBar.vue';
import MobileNavBar from '@/components/MobileNavBar.vue';

export default {
  name: 'Home',
  components: {
    Hero,
    Delta,
    Echo,
    Alpha,
    NavBar,
    MobileNavBar
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
  font-family: "Funnel Display", sans-serif;
}

a {
  text-decoration: none;
}


.Hero__bg {
  position: relative;
  width: 100%;
  height: 450px;
  background: url('@/Images/bg.png') no-repeat center center;
  background-size: cover;
  display: flex;
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
  background-color: #f3f7f8;
  color: #FFF;
  height: 400px;
  padding-inline: 5rem;
  display: flex;
  justify-content: center;
  align-items: center;
}

.Echo {
  height: 700px;
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}

.Alpha {
  height: 500px;
  background-color: transparent;
  display: flex;
  justify-content: center;
  align-items: center;
}

@media (max-width: 1280px) {
  .Delta {
    height: 650px;
  }

  .Content-section .Echo {
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .Echo {
    height: 700px;
    width: 100%;
  }

  .Alpha{
    height: 500px;
  }
}

@media (max-width: 1024px) {
  .Hero__bg {
    height: 500px;
  }

  .Delta {
    height: 1000px;
  }

  .Echo {
    height: 1000px;
    width: 100%;
  }

  .Alpha{
    height: 700px;
  }
}

@media (max-width: 768px) {
  .Hero__bg {
    height: 400px;
  }

  .Delta {
    height: 500px;
  }

  .Echo {
    height: 1000px;
    width: 100%;
  }

  .Alpha{
    height: 1000px;
  }

}

@media (max-width: 480px) {
  .Hero__bg {
    height: 500px;
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
</style>