const weerStatus = document.querySelector("#weer-status");
const weerInfo = document.querySelector("#weer-info");
const weerFormulier = document.querySelector("#weer-formulier");
const stadVeld = document.querySelector("#stad");
const stadFout = document.querySelector("#stad-fout");

const toonStadFout = (melding) => {
  stadFout.textContent = melding;
  if (melding === "") {
    stadVeld.removeAttribute("aria-invalid");
  } else {
    stadVeld.setAttribute("aria-invalid", "true");
  }
};

const zoekStad = (naam) => {
  const url = `https://geocoding-api.open-meteo.com/v1/search?name=${encodeURIComponent(naam)}&count=1&language=nl`;

  return fetch(url)
    .then((response) => {
      if (!response.ok) {
        throw new Error("Geocoding-API gaf een fout");
      }
      return response.json();
    })
    .then((data) => {
      if (!data.results) {
        throw new Error("Stad niet gevonden");
      }
      return data.results[0];
    });
};

const haalWeerOp = (stad) => {
  const url = `https://api.open-meteo.com/v1/forecast?latitude=${stad.latitude}&longitude=${stad.longitude}&current=temperature_2m,weather_code&timezone=auto`;

  return fetch(url).then((response) => {
    if (!response.ok) {
      throw new Error("Weer-API gaf een fout");
    }
    return response.json();
  });
};

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

const toonWeer = (weer, stad) => {
  const plaats = document.createElement("p");
  plaats.classList.add("weer__stad");
  plaats.textContent = `${stad.name}, ${stad.country}`;

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
  bijgewerkt.append("Bijgewerkt om ", tijd, " (lokale tijd)");

  weerInfo.append(plaats, temperatuur, omschrijving, bijgewerkt);
};

const laadWeer = (naam) => {
  weerInfo.innerHTML = "";
  weerStatus.textContent = "Weer laden…";

  let gevondenStad;

  zoekStad(naam)
    .then((stad) => {
      gevondenStad = stad;
      return haalWeerOp(stad);
    })
    .then((data) => {
      weerStatus.textContent = "";
      toonWeer(data.current, gevondenStad);
    })
    .catch((fout) => {
      console.error("Weer laden mislukt:", fout);
      if (fout.message === "Stad niet gevonden") {
        weerStatus.textContent = "";
        toonStadFout(`De stad "${naam}" is niet gevonden. Controleer de spelling.`);
        stadVeld.focus();
      } else {
        weerStatus.textContent =
          "Het weer kon niet worden geladen. Probeer het later opnieuw.";
      }
    });
};

const verwerkZoekopdracht = (event) => {
  event.preventDefault();
  const naam = stadVeld.value.trim();

  if (naam === "") {
    weerInfo.innerHTML = "";
    weerStatus.textContent = "";
    toonStadFout("Vul een stad in.");
    stadVeld.focus();
    return;
  }

  toonStadFout("");
  laadWeer(naam);
};

weerFormulier.addEventListener("submit", verwerkZoekopdracht);