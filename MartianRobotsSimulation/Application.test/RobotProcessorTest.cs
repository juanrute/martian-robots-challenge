using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace Application.Test
{
    public class RobotProcessorTest
    {
        RobotProcessor processor;

        [SetUp]
        public void Setup()
        {
            processor = new RobotProcessor();
            processor.MarsSurface = new MarsSurface();
        }

        [Test]
        public void ExcecuteEachRobotCommand_WhenExampleInput_ExpectedCorrectOutput()
        {
            var testData = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"\TestData\exampleInput.txt")
                .Where(line => !string.IsNullOrWhiteSpace(line));
            var result = processor.ExcecuteEachRobotCommand(testData.ToList()).Select(res => res.FinalRobotPosition).ToList();

            //Output for 3 robots
            Assert.AreEqual(3,result.Count);

            Assert.AreEqual("1 1 E", result[0]);
            Assert.AreEqual("3 3 N LOST", result[1]);
            Assert.AreEqual("4 2 N", result[2]);
        }

        [Test]
        public void ExcecuteEachRobotCommand_WhenARobotLeftScent_ExpectedNextRobotSkipACommand()
        {
            var testData = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"\TestData\scentsInput.txt")
                .Where(line => !string.IsNullOrWhiteSpace(line));
            var result = processor.ExcecuteEachRobotCommand(testData.ToList()).Select(res => res.FinalRobotPosition).ToList();

            Assert.AreEqual("2 2 E LOST", result[0]);
            Assert.AreEqual("2 1 S", result[1]);
        }

        [Test]
        public void ExcecuteEachRobotCommand_WhenMiddleInput_ExpectedCorrectOutput()
        {
            var testData = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"\TestData\middleInput.txt")
                .Where(line => !string.IsNullOrWhiteSpace(line));
            var result = processor.ExcecuteEachRobotCommand(testData.ToList()).Select(res => res.FinalRobotPosition).ToList();
            
            //Output for 6 robots
            Assert.AreEqual(6, result.Count);

            //Robot 1: Starting from (0 0 N) and moving with the pattern FRFL 24 times
            Assert.AreEqual("24 24 N", result[0]);

            //Robot 2: Starting from (25 25 S) and moving with the pattern FRFL 24 times
            Assert.AreEqual("1 1 S", result[1]);

            //Robot 3: Starting from (10 10 N) and moving with the pattern FLFL 24 times ends up in the initial position
            Assert.AreEqual("10 10 N", result[2]);

            //Robot 4: Starting from (0 0 N) and moving with the pattern FRFL 24 times and one aditional F movement
            Assert.AreEqual("24 25 N", result[3]);

            //Robot 5: Starting from (25 25 S) and moving with the pattern F 25 times then R and F 25 times then R and F until lost
            Assert.AreEqual("0 25 N LOST", result[4]);

            //Robot 6: Starting from (0 0 S) and try to move forward
            Assert.AreEqual("0 0 S LOST", result[5]);
        }


        [Test]
        public void ExcecuteEachRobotCommand_WhenLongInput_ExpectedCorrectOutput()
        {
            var testData = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"\TestData\longInput.txt")
                .Where(line => !string.IsNullOrWhiteSpace(line));
            var result = processor.ExcecuteEachRobotCommand(testData.ToList()).Select(res => res.FinalRobotPosition).ToList();

            //Output for 40 robots
            Assert.AreEqual(48, result.Count);

            //Robots [1-4]: Starting from (0 0 N) and moving forward 50 times then R and forward 49 times
            Assert.AreEqual("49 50 E", result[0]);
            Assert.AreEqual("49 50 E", result[1]);
            Assert.AreEqual("49 50 E", result[2]);
            Assert.AreEqual("49 50 E", result[3]);

            //Robots [5-8]: Starting from (50 50 S) and moving forward 50 times then R and forward 49 times
            Assert.AreEqual("1 0 W", result[4]);
            Assert.AreEqual("1 0 W", result[5]);
            Assert.AreEqual("1 0 W", result[6]);
            Assert.AreEqual("1 0 W", result[7]);

            Assert.AreEqual("25 25 N", result[8]);
            Assert.AreEqual("25 25 N", result[9]);
            Assert.AreEqual("25 25 N", result[10]);
            Assert.AreEqual("25 25 N", result[11]);

            Assert.AreEqual("24 24 S", result[12]);
            Assert.AreEqual("24 24 S", result[13]);
            Assert.AreEqual("24 24 S", result[14]);
            Assert.AreEqual("24 24 S", result[15]);

            Assert.AreEqual("50 50 E LOST", result[16]);
            //Because of the scent left by the last robot, the others does not fall
            Assert.AreEqual("50 50 E", result[17]);
            Assert.AreEqual("50 50 E", result[18]);
            Assert.AreEqual("50 50 E", result[19]);

            //Robot [20-24]: Starting from (25 25 S) and moving with the pattern F 25 times then R and F 25 times then R and F until lost
            Assert.AreEqual("0 45 N", result[20]);
            Assert.AreEqual("0 45 N", result[21]);
            Assert.AreEqual("0 45 N", result[22]);
            Assert.AreEqual("0 45 N", result[23]);

            //To make the test long, I sent the same commands to the next 24 robots
            Assert.AreEqual("0 45 N", result[47]);
        }

        [Test]
        public void IsCommandValid_WhenCorrectCommand_ExpectedTrue()
        {
            var testData = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"\TestData\exampleInput.txt")
                .Where(line => !string.IsNullOrWhiteSpace(line));
            processor.IsCommandValid(testData.ToList());

        }

        [Test]
        public void IsCommandValid_WhenInvalidCommand_ExpectedArgumentExceptionInvalidInput()
        {
            var testData = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"\TestData\wrongInput.txt")
                .Where(line => !string.IsNullOrWhiteSpace(line));
            var ex = Assert.Throws<ArgumentException>(() => processor.IsCommandValid(testData.ToList()));

            Assert.That(ex.Message == "Invalid command.");
        }

        [Test]
        public void IsCommandValid_WhenInvalidCommand_ExpectedArgumentExceptionInstructionLength()
        {
            var testData = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"\TestData\wrongInputCommandLen.txt")
                .Where(line => !string.IsNullOrWhiteSpace(line));
            var ex = Assert.Throws<ArgumentException>(() => processor.IsCommandValid(testData.ToList()));

            Assert.That(ex.Message == "Instructions length must be less or equals to 100.");
        }

        [Test]
        public void IsCommandValid_WhenInvalidCommand_ExpectedArgumentExceptionCoordinateLength()
        {
            var testData = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"\TestData\wrongInputCoordinateLen.txt")
                .Where(line => !string.IsNullOrWhiteSpace(line));
            var ex = Assert.Throws<ArgumentException>(() => processor.IsCommandValid(testData.ToList()));

            Assert.That(ex.Message == "Coordinates length must be less or equals to 50.");
        }

        [Test]
        public void IsCommandValid_WhenInvalidCommand_ExpectedArgumentExceptionInstructionCharacter()
        {
            var testData = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"\TestData\wrongInstructionsInput.txt")
                .Where(line => !string.IsNullOrWhiteSpace(line));
            var ex = Assert.Throws<ArgumentException>(() => processor.IsCommandValid(testData.ToList()));

            Assert.That(ex.Message == "Invalid instructions character.");
        }


        [Test]
        public void IsCommandValid_WhenInvalidCommand_ExpectedArgumentExceptionRobotInvalidCoordinates()
        {
            var testData = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"\TestData\wrongInputRobotCoordinateLen.txt")
                .Where(line => !string.IsNullOrWhiteSpace(line));

            var ex = Assert.Throws<ArgumentException>(() => processor.ExcecuteEachRobotCommand(testData.ToList()));

            Assert.That(ex.Message == "Coordinates length must be less or equals to 50.");
        }

        [Test]
        public void IsCommandValid_WhenInvalidCommand_ExpectedArgumentExceptionRobotInvalidOrientation()
        {
            var testData = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"\TestData\wrongInputRobotOrientation.txt")
                .Where(line => !string.IsNullOrWhiteSpace(line));

            var ex = Assert.Throws<ArgumentException>(() => processor.IsCommandValid(testData.ToList()));

            Assert.That(ex.Message == "Invalid character for robot orientation.");
        }
    }
}