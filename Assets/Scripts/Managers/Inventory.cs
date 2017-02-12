using UnityEngine;
using System.Collections;

public class Inventory {
    public double maxWood;
    public double maxMushroom;
    public double maxIron;
    private double wood = 0.00;
    private double mushroom = 0.00;
    private double iron = 0.00;

    public Inventory(double maxWood, double maxMushroom, double maxIron) {
        this.maxWood = maxWood;
        this.maxMushroom = maxMushroom;
        this.maxIron = maxIron;
    }

    // Add/Remove Resources
    public void addWood(double wood) {
        this.wood += wood;
    }

    public void addMushroom() {
        this.mushroom += mushroom;
    }

    public void addIron() {
        this.iron += iron;
    }

    // Accessors
    public double getWood() {
        return wood;
    }

    public double getMushroom() {
        return mushroom;
    }

    public double getIron() {
        return iron;
    }
}
