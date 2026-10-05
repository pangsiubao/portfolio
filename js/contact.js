const formulier = document.querySelector("#contactformulier");
const naamVeld = document.querySelector("#naam");
const emailVeld = document.querySelector("#email");
const berichtVeld = document.querySelector("#bericht");
const bevestiging = document.querySelector("#bevestiging");

const minimaleLengte = 20;

const controleerNaam = (naam) => {
  if (naam.trim() === "") {
    return "Vul je naam in.";
  }
  return "";
};

const controleerEmail = (email) => {
  const emailPatroon = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

  if (email.trim() === "") {
    return "Vul je e-mailadres in.";
  }
  if (!emailPatroon.test(email.trim())) {
    return "Vul een geldig e-mailadres in, bijvoorbeeld naam@voorbeeld.nl.";
  }
  return "";
};

const controleerBericht = (bericht) => {
  const lengte = bericht.trim().length;

  if (lengte < minimaleLengte) {
    return `Je bericht moet minimaal ${minimaleLengte} tekens hebben.`;
  }
  return "";
};

const toonFout = (veld, melding) => {
  const foutElement = document.querySelector(`#${veld.id}-fout`);
  foutElement.textContent = melding;

  if (melding === "") {
    veld.removeAttribute("aria-invalid");
  } else {
    veld.setAttribute("aria-invalid", "true");
  }
};

const controleerVeld = (veld, controleFunctie) => {
  const melding = controleFunctie(veld.value);
  toonFout(veld, melding);
  return melding === "";
};

const verwerkFormulier = (event) => {
  event.preventDefault();
  bevestiging.textContent = "";

  const naamGoed = controleerVeld(naamVeld, controleerNaam);
  const emailGoed = controleerVeld(emailVeld, controleerEmail);
  const berichtGoed = controleerVeld(berichtVeld, controleerBericht);

  if (!naamGoed) {
    naamVeld.focus();
  } else if (!emailGoed) {
    emailVeld.focus();
  } else if (!berichtGoed) {
    berichtVeld.focus();
  } else {
    bevestiging.textContent = `Bedankt, ${naamVeld.value.trim()}! Je bericht is verstuurd.`;
    formulier.reset();
  }
};

formulier.addEventListener("submit", verwerkFormulier);