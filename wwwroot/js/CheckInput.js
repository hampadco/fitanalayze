
       var inputs = document.querySelectorAll("input[required]");

        for (var i = 0; i < inputs.length; i++) {
        inputs[i].addEventListener("input", function() {
            if (this.validity.valueMissing) {
            this.setCustomValidity("پر کردن این فیلد ضروری است");
            } else {
            this.setCustomValidity("");
            }
        });

        inputs[i].addEventListener("invalid", function() {
            this.setCustomValidity("پر کردن این فیلد ضروری است");
        });
        }

