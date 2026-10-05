// Elementen uit de HTML
const weerStatus = document.querySelector("#weer-status");
const weerInfo = document.querySelector("#weer-info");

// Adres van de API: huidige temperatuur en weercode voor Den Haag
const weerUrl =
  "https://api.open-meteo.com/v1/forecast?latitude=52.08&longitude=4.30&current=temperature_2m,weather_code&timezone=Europe%2FAmsterdam";

// Zet de weercode van de API om naar een omschrijving
const beschrijfWeer = (code) => {
  if (code === 0) {
    return "Onbewolkt";
  } else if (code <= 2) {
    return "Licht bewolkt";
  } else if (code === 3) {
    return "Bewolkt";
  } else if (code <= 48) {
    return "Mist";
  } else if (code <= 57) {
    return "Motregen";
  } else if (code <= 67) {
    return "Regen";
  } else if (code <= 77) {
    return "Sneeuw";
  } else if (code <= 82) {
    return "Regenbuien";
  } else if (code <= 86) {
    return "Sneeuwbuien";
  } else {
    return "Onweer";
  }
};

// Zet het weer op de pagina
const toonWeer = (weer) => {
  const temperatuur = document.createElement("p");
  temperatuur.classList.add("weer__temperatuur");
  temperatuur.textContent = `${Math.round(weer.temperature_2m)} °C`;

  const omschrijving = document.createElement("p");
  omschrijving.textContent = beschrijfWeer(weer.weather_code);

  const tijd = document.createElement("time");
  tijd.dateTime = weer.time;
  tijd.textContent = weer.time.slice(11, 16);

  const bijgewerkt = document.createElement("p");
  bijgewerkt.classList.add("weer__tijd");
  bijgewerkt.append("Bijgewerkt om ", tijd);

  weerInfo.append(temperatuur, omschrijving, bijgewerkt);
};

// Haalt het actuele weer op bij Open-Meteo
const laadWeer = () => {
  fetch(weerUrl)
    .then((response) => {
      if (!response.ok) {
        throw new Error("Weer-API gaf een fout");
      }
      return response.json();
    })
    .then((data) => {
      weerStatus.textContent = "";
      toonWeer(data.current);
    })
    .catch((fout) => {
      console.error("Weer laden mislukt:", fout);
      weerStatus.textContent =
        "Het weer kon niet worden geladen. Probeer het later opnieuw.";
    });
};

laadWeer();